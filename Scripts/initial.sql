DROP DATABASE IF EXISTS finapp;
CREATE DATABASE finapp;
USE finapp;
CREATE TABLE `user` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(255) DEFAULT NULL,
  `photoURL` VARCHAR(255) DEFAULT NULL,
  `displayName` VARCHAR(255) DEFAULT NULL,
  `password` VARCHAR(255) DEFAULT NULL,
  `emailConfirmed` TINYINT NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `tag` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(255) DEFAULT NULL,
  `userId` INT DEFAULT NULL,
  `system` TINYINT(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userId` (`userId`),
  CONSTRAINT `tag_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `account` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `currency` VARCHAR(50) NOT NULL DEFAULT 'HRK',
  `icon` VARCHAR(50) NOT NULL DEFAULT 'eye',
  `description` VARCHAR(255) DEFAULT NULL,
  `userId` INT DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userId` (`userId`),
  CONSTRAINT `account_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `locale` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `text` VARCHAR(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `settings` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `darkMode` TINYINT(1) DEFAULT NULL,
  `localeId` INT DEFAULT NULL,
  `preferredCurrency` VARCHAR(50) NOT NULL DEFAULT 'HRK',
  `dateFormat` VARCHAR(50) NOT NULL DEFAULT 'dd.MM.yyyy. HH:mm',
  `userId` INT DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userId` (`userId`),
  CONSTRAINT `settings_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`id`),
  CONSTRAINT `settings_ibfk_2` FOREIGN KEY (`localeId`) REFERENCES `locale` (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `transaction` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `amount` DOUBLE DEFAULT NULL,
  `createdAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `description` VARCHAR(255) DEFAULT NULL,
  `expense` TINYINT(1) DEFAULT NULL,
  `accountId` INT DEFAULT NULL,
  `userId` INT DEFAULT NULL,
  `transfer` TINYINT NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `userId` (`userId`),
  KEY `accountId` (`accountId`),
  CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`id`),
  CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`accountId`) REFERENCES `account` (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `transactiontag` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `transactionId` INT DEFAULT NULL,
  `tagId` INT DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `transactionId` (`transactionId`),
  KEY `tagId` (`tagId`),
  CONSTRAINT `transactiontag_ibfk_1` FOREIGN KEY (`transactionId`) REFERENCES `transaction` (`id`),
  CONSTRAINT `transactiontag_ibfk_2` FOREIGN KEY (`tagId`) REFERENCES `tag` (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
CREATE TABLE `history` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `accountId` INT DEFAULT NULL,
  `amount` DOUBLE NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `userId` INT DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `accountId` (`accountId`),
  KEY `userId` (`userId`),
  CONSTRAINT `history_ibfk_1` FOREIGN KEY (`accountId`) REFERENCES `account` (`id`),
  CONSTRAINT `history_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `user` (`id`)
) ENGINE = INNODB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8 COLLATE = utf8_general_ci;
-- Triggers
DELIMITER $ $ DROP TRIGGER IF EXISTS userAfterInsertTrigger $ $ CREATE TRIGGER userAfterInsertTrigger
AFTER
INSERT
  ON user FOR EACH ROW BEGIN
INSERT INTO
  settings (userId, darkMode)
VALUES
  (NEW.id, 0);
END $ $ DELIMITER;
DELIMITER $ $ DROP FUNCTION IF EXISTS getPercentageOfTag $ $ CREATE FUNCTION getPercentageOfTag(id INT, userId INT) RETURNS DECIMAL(5, 5) DETERMINISTIC BEGIN DECLARE totalRecords INT DEFAULT 0;
DECLARE requestedRecords INT DEFAULT 0;
SET
  totalRecords = (
    SELECT
      COUNT(DISTINCT(transactionId))
    FROM
      transactiontag fct
      JOIN transaction fc ON fc.id = fct.transactionId
    WHERE
      expense = 1
  );
SET
  requestedRecords = (
    SELECT
      COUNT(*)
    FROM
      transactiontag fct
      JOIN transaction fc ON fc.id = fct.transactionId
    WHERE
      expense = 1
      AND tagId = id
  );
RETURN requestedRecords / totalRecords;
END;
$ $ DELIMITER;
DROP PROCEDURE IF EXISTS getTagPercentages;
DELIMITER $ $ CREATE PROCEDURE getTagPercentages(userId INT) BEGIN DECLARE tId INT DEFAULT 0;
DECLARE tDescription VARCHAR(255) DEFAULT "";
DECLARE finished BOOL DEFAULT FALSE;
DECLARE transferTagId INT DEFAULT 0;
DECLARE curTags CURSOR FOR
SELECT
  id,
  `description`
FROM
  tag;
DECLARE CONTINUE HANDLER FOR NOT FOUND
SET
  finished = TRUE;
DECLARE EXIT HANDLER FOR SQLEXCEPTION
SELECT
  NULL;
DROP TEMPORARY TABLE IF EXISTS tagPercentages;
CREATE TEMPORARY TABLE tagPercentages (
    id INT,
    `description` VARCHAR(255),
    percentage DECIMAL(5, 5)
  );
SET
  transferTagId = (
    SELECT
      id
    FROM
      tag
    WHERE
      `description` LIKE 'Transfer'
  );
OPEN curTags;
tagLoop :LOOP FETCH curTags INTO tId,
  tDescription;
IF finished = TRUE THEN LEAVE tagLoop;
END IF;
IF getPercentageOfTag(tId, userId) > 0 & & transferTagId != tId THEN
INSERT INTO
  tagPercentages (id, `description`, percentage)
VALUES
  (
    tId,
    tDescription,
    getPercentageOfTag(tId, userId)
  );
END IF;
END LOOP;
CLOSE curTags;
SELECT
  *
FROM
  tagPercentages;
END;
$ $ DELIMITER;
DELIMITER $ $ DROP FUNCTION IF EXISTS getDailyAmount $ $ CREATE FUNCTION getDailyAmount(argCreatedAt DATE, argExpense BIT) RETURNS DECIMAL(10, 2) DETERMINISTIC BEGIN DECLARE res DECIMAL(10, 2) DEFAULT 0;
SET
  res = (
    SELECT
      ROUND(SUM(amount), 2)
    FROM
      transaction
    WHERE
      DATE(createdAt) LIKE argCreatedAt
      AND expense = argExpense
      AND transfer = 0
  );
IF res IS NULL THEN RETURN 0;
  ELSE RETURN res;
END IF;
END;
$ $ DELIMITER;
DROP PROCEDURE IF EXISTS getDailyChanges;
DELIMITER $ $ CREATE PROCEDURE getDailyChanges(userId INT) BEGIN DECLARE tCreatedAt DATE;
DECLARE finished BOOL DEFAULT FALSE;
DECLARE curDates CURSOR FOR
SELECT
  DATE(createdAt)
FROM
  history
GROUP BY
  DATE(createdAt)
ORDER BY
  createdAt DESC
LIMIT
  30;
DECLARE CONTINUE HANDLER FOR NOT FOUND
SET
  finished = TRUE;
DECLARE EXIT HANDLER FOR SQLEXCEPTION
SELECT
  NULL;
DROP TEMPORARY TABLE IF EXISTS dailyChanges;
CREATE TEMPORARY TABLE dailyChanges (
    deposits DECIMAL(10, 2),
    withdrawals DECIMAL(10, 2),
    createdAt DATE
  );
OPEN curDates;
datesLoop :LOOP FETCH curDates INTO tCreatedAt;
IF finished = TRUE THEN LEAVE datesLoop;
END IF;
INSERT INTO
  dailyChanges (deposits, withdrawals, createdAt)
VALUES
  (
    (
      SELECT
        getDailyAmount(tCreatedAt, 0)
    ),
    (
      SELECT
        getDailyAmount(tCreatedAt, 1)
    ),
    tCreatedAt
  );
END LOOP;
CLOSE curDates;
SELECT
  *
FROM
  dailyChanges;
END;
$ $ DELIMITER;
-- Inserts
INSERT INTO
  `locale` (`text`)
VALUES
  ("ENG"),
  ("CRO");
INSERT INTO
  `user` (
    `id`,
    `photoURL`,
    `email`,
    `displayName`,
    `password`,
    `emailConfirmed`
  )
VALUES
  (
    1,
    "https://cdn.akamai.steamstatic.com/steamcommunity/public/images/avatars/4d/4d1195ddbccff0cefc947e8f9343e70ecfd3d9c6_full.jpg",
    "mnovosel5@gmail.com",
    "Matija Novosel",
    "$2b$10$SSelNL/mi8qX2o47wN7u6OmhIR6vN7TCwimprKwDbVldTZob9y796",
    0
  );
INSERT INTO
  `account` (
    `id`,
    `currency`,
    `icon`,
    `description`,
    `userId`
  )
VALUES
  (1, "HRK", "credit-card-outline", "Gyro", 1),
  (2, "HRK", "credit-card", "Checking", 1),
  (3, "HRK", "wallet", "Pocket", 1),
  (4, "HRK", "currency-eur", "Euros", 1);
INSERT INTO
  `tag` (`description`, `system`, `userId`)
VALUES
  ('Transfer', 1, null),
  ('Food', 0, 1),
  ('Gifts', 0, 1),
  ('Games', 0, 1),
  ('Public transport', 0, 1),
  ('Other', 0, 1),
  ('Drink', 0, 1),
  ('Groceries', 0, 1),
  ('Academic help', 0, 1),
  ('Technology and devices', 0, 1),
  ('Salary', 0, 1),
  ('Medicine', 0, 1),
  ('Cosmetics', 0, 1),
  ('Rent', 0, 1),
  ('Debt', 0, 1),
  ('Clothes', 0, 1);