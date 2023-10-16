using System;

namespace Web_24BM.Models
{
    public class EnviarFormularioFull
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public DateOnly fecha_nacimiento { get; set; }
        public TimeOnly hora_entrada { get; set; }
        public string turno { get; set; }
        public string comentario {  get; set; }
        public string asunto { get; set; }
    }
}
