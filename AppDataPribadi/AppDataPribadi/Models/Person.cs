using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDataPribadi.Models
{
    public class Person
    {
        [Key]
        [Required(ErrorMessage = "NIK harus diisi")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long NIK { get; set; }

        [Required(ErrorMessage = "nama lengkap harus diisi")]
        public string NamaLengkap { get; set; }

        [Required(ErrorMessage = "jenis KELAMIN harus diisi")]
        public string JenisKelamin { get; set; }

        [Required(ErrorMessage = "tanggal lahir harus diisi")]
        [DataType(DataType.Date)]
        public DateTime TanggalLahir { get; set; }

        [Required(ErrorMessage = "alamat harus diisi")]
        public string Alamat { get; set; }

        [Required(ErrorMessage = "negara harus diisi")]
        public string Negara { get; set; }
    }
}
