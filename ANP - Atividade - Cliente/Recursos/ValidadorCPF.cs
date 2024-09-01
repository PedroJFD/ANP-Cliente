namespace ANP___Atividade___Cliente.Recursos
{
    public static class ValidadorCPF
    {
        public static bool ValidaCPF(string cpf)
        {
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }
            int n1 = int.Parse(cpf[0].ToString());
            int n2 = int.Parse(cpf[1].ToString());
            int n3 = int.Parse(cpf[2].ToString());
            int n4 = int.Parse(cpf[3].ToString());
            int n5 = int.Parse(cpf[4].ToString());
            int n6 = int.Parse(cpf[5].ToString());
            int n7 = int.Parse(cpf[6].ToString());
            int n8 = int.Parse(cpf[7].ToString());
            int n9 = int.Parse(cpf[8].ToString());
            int n10 = int.Parse(cpf[9].ToString());
            int n11 = int.Parse(cpf[10].ToString());
            int primeiracasa = ((10 * n1) + (9 * n2) + (8 * n3) + (7 * n4) + (6 * n5) + (5 * n6) + (4 * n7) + (3 * n8) + (2 * n9)) % 11;
            if (primeiracasa < 2)
            {
                primeiracasa = 0;
            }
            else
            {
                primeiracasa = 11 - primeiracasa;
            }
            if (primeiracasa != n10)
            {
                return false;
            }
            int segundacasa = ((11 * n1) + (10 * n2) + (9 * n3) + (8 * n4) + (7 * n5) + (6 * n6) + (5 * n7) + (4 * n8) + (3 * n9) + (2 * n10)) % 11;
            if (segundacasa < 2)
            {
                segundacasa = 0;
            }
            else
            {
                segundacasa = 11 - segundacasa;
            }
            if (segundacasa != n11)
            {
                return false;
            }
            return true;
        }
    }
}