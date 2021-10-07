using System.Collections.Generic;

namespace MagazinOnline.Models.DTOs.VMDTOs
{
    public class DataSourceCountDTO<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public int Count { get; set; }

        public DataSourceCountDTO()
        { }

        public DataSourceCountDTO(IEnumerable<T> collection, int count)
        {
            Collection = collection;
            Count = count;        
        }
    }
}
