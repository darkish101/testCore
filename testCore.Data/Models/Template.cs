using System.ComponentModel.DataAnnotations.Schema;

namespace testCore.Data
{
    public class Template : BaseEntity<int>
    {
        [Column(Order = 2)]
        public string Name { get; set; }

        [Column(Order = 3)]
        public string Photo { get; set; }
    }
}
