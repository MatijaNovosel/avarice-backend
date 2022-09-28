namespace avarice_backend.Entities.Base
{
  public interface IEntityBase<TId>
  {
    TId Id { get; }
  }
}