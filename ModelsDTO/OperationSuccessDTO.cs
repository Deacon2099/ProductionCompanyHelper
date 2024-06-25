namespace ProductionCompanyHelper.ModelsDTO
{
    public class OperationSuccessDTO<T> : OperationResultDTO
        where T: class
    {
        public T Result { get; set; }
    }
}
