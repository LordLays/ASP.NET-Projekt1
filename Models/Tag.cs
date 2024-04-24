namespace WebApplication1.Models
{
    public class Tag
    {
        public uint IDTag { get; set; }
        public string Name { get; set; }

        public virtual List<Ofert> Hotels { get; set; }

    }
}
