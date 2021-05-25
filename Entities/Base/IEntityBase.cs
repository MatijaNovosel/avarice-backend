namespace fin_app_backend.Entities.Base
{
  public interface IEntityBase<TId>
  {
    TId Id { get; }
  }
}