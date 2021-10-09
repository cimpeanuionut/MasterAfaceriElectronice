namespace ProiectMaster.Models.DTOs
{
    public class IdNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IdNameDto()
        {
        }

        public IdNameDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
