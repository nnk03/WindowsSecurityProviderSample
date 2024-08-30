namespace SecurityProcessorModule
{
    public interface ISecurityProvider
    {
        public void Scan();

        public void OnSecurityEvent();
    }
}
