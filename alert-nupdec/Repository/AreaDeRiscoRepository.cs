using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    class AreaDeRiscoRepository
    {
        public static List<AreaRisco> list_areasderisco = new List<AreaRisco>();

        public List<AreaRisco> ListaAreas
        {
            get { return  list_areasderisco; }
        }

        public static void cadastrarArea(AreaRisco area)
        {
            list_areasderisco.Add(area);
            System.Diagnostics.Debug.WriteLine($"Rua: {area.Rua}" +
                                               $"\nBairro: {area.Bairro}" +
                                               $"\nCEP: {area.CEP}");
        }
    }
}
