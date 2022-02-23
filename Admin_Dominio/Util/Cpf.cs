using ValidaCpf;

namespace Admin_Dominio.Util
{
    public static class Cpf
    {
        public static bool ValidacaoCPF(string cpf)
        {            
            return ValidaCpfExtension.Validate(cpf);;
        }
    }
}