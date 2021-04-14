namespace DTO.Sierra
{
    public class MarcFileLinkResponse
    {
        public string File { get; set; } = default!;
        public int InputRecords { get; set; }
        public int DeletedRecords { get; set; }
        public int OutputRecords { get; set; }
        public int Errors { get; set; }
    }
}