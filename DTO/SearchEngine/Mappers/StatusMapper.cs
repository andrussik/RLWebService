namespace DTO.SearchEngine.Mappers
{
    public class StatusMapper
    {
        public static ItemStatus Map(Sierra.ItemStatus status)
        {
            return new ()
            {
                Code = status.Code,
                Display = status.Display
            };
        }
    }
}