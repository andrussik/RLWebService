namespace MarcReader.MARC
{
    public class SortedMarcFactory : DefaultMarcFactory
    {
        public override IRecord NewRecord(ILeader leader)
        {
            return new SortedRecord()
            {
                Leader = leader
            };
        }
    }
}
