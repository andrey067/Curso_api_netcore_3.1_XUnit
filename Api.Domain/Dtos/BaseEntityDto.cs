using System;

namespace Domain.Dtos
{
    public class BaseEntityDto
    {
        public long? Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
