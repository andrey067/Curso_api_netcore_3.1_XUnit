using System;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime? CreateAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; private set; }
        public void UpdateUpdateAt() => UpdateAt = DateTime.UtcNow;
    }
}