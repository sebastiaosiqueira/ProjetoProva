using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.Service.Utility
{
    namespace Util
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Globalization;
        using System.IO;
        using System.Linq;
        using System.Reflection;
        using System.Runtime.Serialization.Formatters.Binary;
        using System.Security.Cryptography;
        using System.Text;
        using System.Text.RegularExpressions;
        using System.Web.Mvc;
        using System.Xml.Serialization;
        public class Funcoes
        {

            public static long TamanhoDoObjectoEmBytes(object objeto)
            {
                long result = 0L;
                using (Stream stream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, objeto);
                    result = stream.Length;
                }
                return result;
            }

            public static bool VerificarCaracteresEspeciais(string frase)
            {
                IEnumerable<char> source =
                    from c in frase.Normalize(NormalizationForm.FormD).ToCharArray()
                    where CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark || new char[]
				{
					'~',
					'´',
					'`',
					'¨',
					'^',
					'.'
				}.Contains(c)
                    select c;
                return source.Count<char>() > 0;
            }

            public static string FormatarIeCpfCnpj(string str)
            {
                string result;
                if (str == null)
                {
                    result = null;
                }
                else
                {
                    if (str.Length == 9)
                    {
                        result = Funcoes.FormatarIE(str);
                    }
                    else
                    {
                        if (str.Length == 11)
                        {
                            result = Funcoes.FormatarCPF(str);
                        }
                        else
                        {
                            if (str.Length == 14)
                            {
                                result = Funcoes.FormatarCNPJ(str);
                            }
                            else
                            {
                                result = str;
                            }
                        }
                    }
                }
                return result;
            }
            public static string FormatarIeCpfCnpj(string cnpj_cpf, string tipo)
            {
                string result;
                if (string.IsNullOrEmpty(cnpj_cpf))
                {
                    result = cnpj_cpf;
                }
                else
                {
                    cnpj_cpf = ((tipo == "F") ? cnpj_cpf.Substring(cnpj_cpf.Length - 11, 11) : cnpj_cpf.Substring(cnpj_cpf.Length - 14, 14));
                    result = Funcoes.FormatarIeCpfCnpj(cnpj_cpf);
                }
                return result;
            }
            public static string FormatarCPF(string sCPF)
            {
                string result;
                if (sCPF.Length == 11)
                {
                    result = string.Concat(new string[]
				{
					sCPF.Substring(0, 3),
					".",
					sCPF.Substring(3, 3),
					".",
					sCPF.Substring(6, 3),
					"-",
					sCPF.Substring(9, 2)
				});
                }
                else
                {
                    result = sCPF.ToString();
                }
                return result;
            }
            public static string FormatarCNPJ(string sCNPJ)
            {
                string result;
                if (sCNPJ.Length == 14)
                {
                    result = string.Concat(new string[]
				{
					sCNPJ.Substring(0, 2),
					".",
					sCNPJ.Substring(2, 3),
					".",
					sCNPJ.Substring(5, 3),
					"/",
					sCNPJ.Substring(8, 4),
					"-",
					sCNPJ.Substring(12, 2)
				});
                }
                else
                {
                    result = sCNPJ.ToString();
                }
                return result;
            }
            public static string FormatarIE(string sIE)
            {
                string result;
                if (sIE.Length == 9)
                {
                    result = string.Concat(new string[]
				{
					sIE.Substring(0, 2),
					".",
					sIE.Substring(2, 3),
					".",
					sIE.Substring(5, 3),
					"-",
					sIE.Substring(8, 1)
				});
                }
                else
                {
                    result = sIE.ToString();
                }
                return result;
            }
            public static bool validarCpfCnpj(string sNumero)
            {
                bool result;
                try
                {
                    sNumero = sNumero.ToString();
                    int[] array = new int[]
				{
					10,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    int[] array2 = new int[]
				{
					11,
					10,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    sNumero = sNumero.PadLeft(14, '0');
                    if (sNumero.Substring(3, 11).Equals("00000000000") || sNumero.Substring(3, 11).Equals("11111111111") || sNumero.Substring(3, 11).Equals("22222222222") || sNumero.Substring(3, 11).Equals("33333333333") || sNumero.Substring(3, 11).Equals("44444444444") || sNumero.Substring(3, 11).Equals("55555555555") || sNumero.Substring(3, 11).Equals("66666666666") || sNumero.Substring(3, 11).Equals("77777777777") || sNumero.Substring(3, 11).Equals("88888888888") || sNumero.Substring(3, 11).Equals("99999999999"))
                    {
                        result = false;
                    }
                    else
                    {
                        string text = sNumero.Substring(3, 9);
                        int num = 0;
                        for (int i = 0; i < 9; i++)
                        {
                            num += int.Parse(text[i].ToString()) * array[i];
                        }
                        int num2 = num % 11;
                        if (num2 < 2)
                        {
                            num2 = 0;
                        }
                        else
                        {
                            num2 = 11 - num2;
                        }
                        string text2 = num2.ToString();
                        text += text2;
                        num = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            num += int.Parse(text[i].ToString()) * array2[i];
                        }
                        num2 = num % 11;
                        if (num2 < 2)
                        {
                            num2 = 0;
                        }
                        else
                        {
                            num2 = 11 - num2;
                        }
                        text2 += num2.ToString();
                        if (sNumero.EndsWith(text2))
                        {
                            result = true;
                        }
                        else
                        {
                            array = new int[]
						{
							5,
							4,
							3,
							2,
							9,
							8,
							7,
							6,
							5,
							4,
							3,
							2
						};
                            array2 = new int[]
						{
							6,
							5,
							4,
							3,
							2,
							9,
							8,
							7,
							6,
							5,
							4,
							3,
							2
						};
                            if (sNumero.Length != 14)
                            {
                                result = false;
                            }
                            else
                            {
                                if (sNumero.Substring(0, 8).Equals("00000000") || sNumero.Substring(0, 8).Equals("11111111") || sNumero.Substring(0, 8).Equals("22222222") || sNumero.Substring(0, 8).Equals("33333333") || sNumero.Substring(0, 8).Equals("44444444") || sNumero.Substring(0, 8).Equals("55555555") || sNumero.Substring(0, 8).Equals("66666666") || sNumero.Substring(0, 8).Equals("77777777") || sNumero.Substring(0, 8).Equals("88888888") || sNumero.Substring(0, 8).Equals("99999999"))
                                {
                                    result = false;
                                }
                                else
                                {
                                    text = sNumero.Substring(0, 12);
                                    num = 0;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        num += int.Parse(text[i].ToString()) * array[i];
                                    }
                                    num2 = num % 11;
                                    if (num2 < 2)
                                    {
                                        num2 = 0;
                                    }
                                    else
                                    {
                                        num2 = 11 - num2;
                                    }
                                    text2 = num2.ToString();
                                    text += text2;
                                    num = 0;
                                    for (int i = 0; i < 13; i++)
                                    {
                                        num += int.Parse(text[i].ToString()) * array2[i];
                                    }
                                    num2 = num % 11;
                                    if (num2 < 2)
                                    {
                                        num2 = 0;
                                    }
                                    else
                                    {
                                        num2 = 11 - num2;
                                    }
                                    text2 += num2.ToString();
                                    result = sNumero.EndsWith(text2);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
            public static bool ValidarCpf(string sNumero)
            {
                bool result;
                try
                {
                    sNumero = sNumero.ToString();
                    int[] array = new int[]
				{
					10,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    int[] array2 = new int[]
				{
					11,
					10,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    sNumero = sNumero.PadLeft(14, '0');
                    if (sNumero.Substring(3, 11).Equals("00000000000") || sNumero.Substring(3, 11).Equals("11111111111") || sNumero.Substring(3, 11).Equals("22222222222") || sNumero.Substring(3, 11).Equals("33333333333") || sNumero.Substring(3, 11).Equals("44444444444") || sNumero.Substring(3, 11).Equals("55555555555") || sNumero.Substring(3, 11).Equals("66666666666") || sNumero.Substring(3, 11).Equals("77777777777") || sNumero.Substring(3, 11).Equals("88888888888") || sNumero.Substring(3, 11).Equals("99999999999"))
                    {
                        result = false;
                    }
                    else
                    {
                        string text = sNumero.Substring(3, 9);
                        int num = 0;
                        for (int i = 0; i < 9; i++)
                        {
                            num += int.Parse(text[i].ToString()) * array[i];
                        }
                        int num2 = num % 11;
                        if (num2 < 2)
                        {
                            num2 = 0;
                        }
                        else
                        {
                            num2 = 11 - num2;
                        }
                        string text2 = num2.ToString();
                        text += text2;
                        num = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            num += int.Parse(text[i].ToString()) * array2[i];
                        }
                        num2 = num % 11;
                        if (num2 < 2)
                        {
                            num2 = 0;
                        }
                        else
                        {
                            num2 = 11 - num2;
                        }
                        text2 += num2.ToString();
                        result = sNumero.EndsWith(text2);
                    }
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
            public static bool ValidarCnpj(string sNumero)
            {
                bool result;
                try
                {
                    sNumero = sNumero.ToString();
                    int[] array = new int[]
				{
					5,
					4,
					3,
					2,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    int[] array2 = new int[]
				{
					6,
					5,
					4,
					3,
					2,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    if (sNumero.Length != 14)
                    {
                        result = false;
                    }
                    else
                    {
                        if (sNumero.Substring(0, 8).Equals("00000000") || sNumero.Substring(0, 8).Equals("11111111") || sNumero.Substring(0, 8).Equals("22222222") || sNumero.Substring(0, 8).Equals("33333333") || sNumero.Substring(0, 8).Equals("44444444") || sNumero.Substring(0, 8).Equals("55555555") || sNumero.Substring(0, 8).Equals("66666666") || sNumero.Substring(0, 8).Equals("77777777") || sNumero.Substring(0, 8).Equals("88888888") || sNumero.Substring(0, 8).Equals("99999999"))
                        {
                            result = false;
                        }
                        else
                        {
                            string text = sNumero.Substring(0, 12);
                            int num = 0;
                            for (int i = 0; i < 12; i++)
                            {
                                num += int.Parse(text[i].ToString()) * array[i];
                            }
                            int num2 = num % 11;
                            if (num2 < 2)
                            {
                                num2 = 0;
                            }
                            else
                            {
                                num2 = 11 - num2;
                            }
                            string text2 = num2.ToString();
                            text += text2;
                            num = 0;
                            for (int i = 0; i < 13; i++)
                            {
                                num += int.Parse(text[i].ToString()) * array2[i];
                            }
                            num2 = num % 11;
                            if (num2 < 2)
                            {
                                num2 = 0;
                            }
                            else
                            {
                                num2 = 11 - num2;
                            }
                            text2 += num2.ToString();
                            result = sNumero.EndsWith(text2);
                        }
                    }
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
            public static bool Validar_IE_CPF_CNPJ(string sID, ref string mMensagem)
            {
                bool result;
                try
                {
                    int[] array = new int[]
				{
					10,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    int[] array2 = new int[]
				{
					11,
					10,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    int[] array3 = new int[]
				{
					5,
					4,
					3,
					2,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    int[] array4 = new int[]
				{
					6,
					5,
					4,
					3,
					2,
					9,
					8,
					7,
					6,
					5,
					4,
					3,
					2
				};
                    string text = string.Empty;
                    string text2 = string.Empty;
                    int num = 0;
                    sID = sID.Trim();
                    sID = sID.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");
                    int length = sID.Length;
                    int num2 = length;
                    switch (num2)
                    {
                        case 9:
                            {
                                int i;
                                for (i = 0; i <= 7; i++)
                                {
                                    num += Convert.ToInt32(sID.Substring(i, 1)) * (i + 2);
                                }
                                num *= 10;
                                i = num % 11;
                                string text3;
                                if (i == 0 | i == 1)
                                {
                                    text3 = "0";
                                }
                                else
                                {
                                    text3 = (11 - i).ToString();
                                }
                                if (sID.Substring(8, 1) == text3)
                                {
                                    result = true;
                                    return result;
                                }
                                mMensagem = "Inscrição Estadual Inválida";
                                result = false;
                                return result;
                            }
                        case 10:
                            break;
                        case 11:
                            {
                                text = sID.Substring(0, 9);
                                for (int j = 0; j < 9; j++)
                                {
                                    num += int.Parse(text[j].ToString()) * array[j];
                                }
                                int num3 = num % 11;
                                if (num3 < 2)
                                {
                                    num3 = 0;
                                }
                                else
                                {
                                    num3 = 11 - num3;
                                }
                                string text3 = num3.ToString();
                                text += text3;
                                num = 0;
                                for (int j = 0; j < 10; j++)
                                {
                                    num += int.Parse(text[j].ToString()) * array2[j];
                                }
                                num3 = num % 11;
                                if (num3 < 2)
                                {
                                    num3 = 0;
                                }
                                else
                                {
                                    num3 = 11 - num3;
                                }
                                text3 += num3.ToString();
                                if (sID.Substring(9, 2) == text3)
                                {
                                    result = true;
                                    return result;
                                }
                                mMensagem = "CPF Inválido";
                                result = false;
                                return result;
                            }
                        default:
                            if (num2 == 14)
                            {
                                text2 = sID.Substring(0, 12);
                                for (int j = 0; j < 12; j++)
                                {
                                    num += int.Parse(text2[j].ToString()) * array3[j];
                                }
                                int num3 = num % 11;
                                if (num3 < 2)
                                {
                                    num3 = 0;
                                }
                                else
                                {
                                    num3 = 11 - num3;
                                }
                                string text3 = num3.ToString();
                                text2 += text3;
                                num = 0;
                                for (int j = 0; j < 13; j++)
                                {
                                    num += int.Parse(text2[j].ToString()) * array4[j];
                                }
                                num3 = num % 11;
                                if (num3 < 2)
                                {
                                    num3 = 0;
                                }
                                else
                                {
                                    num3 = 11 - num3;
                                }
                                text3 += num3.ToString();
                                if (sID.Substring(12, 2) == text3)
                                {
                                    result = true;
                                    return result;
                                }
                                mMensagem = "CNPJ Inválido";
                                result = false;
                                return result;
                            }
                            break;
                    }
                    mMensagem = "Quantidade de caracteres inválida...";
                    result = false;
                }
                catch (Exception ex)
                {
                    mMensagem = ex.Message;
                    result = false;
                }
                return result;
            }
     

           
            public static bool validaEmail(string inputEmail)
            {
                bool result = false;
                try
                {
                    string pattern = "^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$";
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
                    if (regex.IsMatch(inputEmail))
                    {
                        result = true;
                    }
                }
                catch
                {
                    result = false;
                }
                return result;
            }
            public static string RemoveAcentos(string texto)
            {
                texto = texto.Normalize(NormalizationForm.FormD);
                StringBuilder stringBuilder = new StringBuilder();
                char[] array = texto.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    char c = array[i];
                    if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }
                return stringBuilder.ToString();
            }
            public static string RemoveCaracteres(string texto)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("([\\\\ª\\\\º\\\\=\\\\°\\\\{\\\\}\\\\\\[\\\\\\]\\\\/\\\\+\\\\)\\\\(\\\\#\\\\%\\\\¨\\\\&\\\\*\\\\_\\[\\-\\]\\!\\\\@\\\\,\\\\;\\\\'\\\\.\\\\^\\\\~\\\\´\\\\`])");
                return regex.Replace(texto, "");
            }
            public static T ConvertStringToEnum<T>(string enumString)
            {
                T result;
                try
                {
                    result = (T)((object)Enum.Parse(typeof(T), enumString, true));
                }
                catch (Exception innerException)
                {
                    T t = default(T);
                    string message = string.Format("'{0}' enumerador invalido para '{1}'", enumString, t.GetType().Name);
                    throw new Exception(message, innerException);
                }
                return result;
            }
            public static string ReadXmlEnumAttribute(Enum value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                XmlEnumAttribute[] array = (XmlEnumAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(XmlEnumAttribute), true);
                string result;
                if (array.Length > 0)
                {
                    result = array[0].Name;
                }
                else
                {
                    result = value.ToString();
                }
                return result;
            }
            public static bool validarChaveAcesso(string Str)
            {
                bool result;
                if (Str.Length != 44)
                {
                    result = false;
                }
                else
                {
                    string value = Funcoes.GerarChaveAcesso(Str.Substring(0, 43));
                    result = Str.Equals(value);
                }
                return result;
            }
            private static string GerarChaveAcesso(string Str)
            {
                string result;
                try
                {
                    if (string.IsNullOrEmpty(Str) || Str.Length != 43)
                    {
                        result = null;
                    }
                    else
                    {
                        int num = 0;
                        num += int.Parse(Str.Substring(0, 1)) * 4;
                        num += int.Parse(Str.Substring(1, 1)) * 3;
                        num += int.Parse(Str.Substring(2, 1)) * 2;
                        num += int.Parse(Str.Substring(3, 1)) * 9;
                        num += int.Parse(Str.Substring(4, 1)) * 8;
                        num += int.Parse(Str.Substring(5, 1)) * 7;
                        num += int.Parse(Str.Substring(6, 1)) * 6;
                        num += int.Parse(Str.Substring(7, 1)) * 5;
                        num += int.Parse(Str.Substring(8, 1)) * 4;
                        num += int.Parse(Str.Substring(9, 1)) * 3;
                        num += int.Parse(Str.Substring(10, 1)) * 2;
                        num += int.Parse(Str.Substring(11, 1)) * 9;
                        num += int.Parse(Str.Substring(12, 1)) * 8;
                        num += int.Parse(Str.Substring(13, 1)) * 7;
                        num += int.Parse(Str.Substring(14, 1)) * 6;
                        num += int.Parse(Str.Substring(15, 1)) * 5;
                        num += int.Parse(Str.Substring(16, 1)) * 4;
                        num += int.Parse(Str.Substring(17, 1)) * 3;
                        num += int.Parse(Str.Substring(18, 1)) * 2;
                        num += int.Parse(Str.Substring(19, 1)) * 9;
                        num += int.Parse(Str.Substring(20, 1)) * 8;
                        num += int.Parse(Str.Substring(21, 1)) * 7;
                        num += int.Parse(Str.Substring(22, 1)) * 6;
                        num += int.Parse(Str.Substring(23, 1)) * 5;
                        num += int.Parse(Str.Substring(24, 1)) * 4;
                        num += int.Parse(Str.Substring(25, 1)) * 3;
                        num += int.Parse(Str.Substring(26, 1)) * 2;
                        num += int.Parse(Str.Substring(27, 1)) * 9;
                        num += int.Parse(Str.Substring(28, 1)) * 8;
                        num += int.Parse(Str.Substring(29, 1)) * 7;
                        num += int.Parse(Str.Substring(30, 1)) * 6;
                        num += int.Parse(Str.Substring(31, 1)) * 5;
                        num += int.Parse(Str.Substring(32, 1)) * 4;
                        num += int.Parse(Str.Substring(33, 1)) * 3;
                        num += int.Parse(Str.Substring(34, 1)) * 2;
                        num += int.Parse(Str.Substring(35, 1)) * 9;
                        num += int.Parse(Str.Substring(36, 1)) * 8;
                        num += int.Parse(Str.Substring(37, 1)) * 7;
                        num += int.Parse(Str.Substring(38, 1)) * 6;
                        num += int.Parse(Str.Substring(39, 1)) * 5;
                        num += int.Parse(Str.Substring(40, 1)) * 4;
                        num += int.Parse(Str.Substring(41, 1)) * 3;
                        num += int.Parse(Str.Substring(42, 1)) * 2;
                        int num2 = num % 11;
                        if (num2 < 2)
                        {
                            num2 = 0;
                        }
                        else
                        {
                            num2 = 11 - num2;
                        }
                        result = string.Format("{0}{1}", Str, num2);
                    }
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
            public static int verificarTipoDocumento(string CnpjCpf)
            {
                int num = -1;
                string empty = string.Empty;
                if (Funcoes.Validar_IE_CPF_CNPJ((CnpjCpf.Length == 14) ? CnpjCpf.Remove(0, 3) : CnpjCpf, ref empty))
                {
                    num++;
                }
                int result;
                if (CnpjCpf.Substring(7, 4) == "0000")
                {
                    result = num;
                }
                else
                {
                    if (CnpjCpf.Substring(0, 8) == "00000000" || Convert.ToInt16(CnpjCpf.Substring(8, 4)) <= 300 || CnpjCpf.Substring(0, 3) != "000")
                    {
                        if (Funcoes.Validar_IE_CPF_CNPJ(CnpjCpf, ref empty))
                        {
                            num += 2;
                        }
                    }
                    result = num;
                }
                return result;
            }

            public static int CalcularIdade(DateTime DataNasc)
            {
                DateTime now = DateTime.Now;
                TimeSpan t = now - DataNasc;
                int result = 0;
                int num;
                if (((DataNasc.Year % 4 == 0 && DataNasc.Year % 100 != 0) || DataNasc.Year % 400 == 0).Equals(true))
                {
                    num = 366;
                }
                else
                {
                    num = 365;
                }
                if (t.Days >= num)
                {
                    result = (default(DateTime) + t).AddYears(-1).Year;
                }
                return result;
            }

            public static bool carregarObjeto(ref object instancia, DataRow linha, ref string sMensagem)
            {
                bool result;
                try
                {
                    foreach (DataColumn dataColumn in linha.Table.Columns)
                    {
                        string a = dataColumn.ColumnName.ToLower();
                        Type type = linha[dataColumn].GetType();
                        PropertyInfo[] properties = instancia.GetType().GetProperties();
                        PropertyInfo[] array = properties;
                        for (int i = 0; i < array.Length; i++)
                        {
                            PropertyInfo propertyInfo = array[i];
                            if (a == propertyInfo.Name.ToLower())
                            {
                                if (linha[dataColumn.ColumnName] != DBNull.Value)
                                {
                                    try
                                    {
                                        propertyInfo.SetValue(instancia, linha[dataColumn.ColumnName], null);
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(ex.Message + "Campo há verificar [ " + dataColumn.ColumnName.ToString().ToUpper() + " ]");
                                    }
                                }
                                if (propertyInfo.ToString().IndexOf("String") > 0)
                                {
                                    propertyInfo.SetValue(instancia, "", null);
                                    break;
                                }
                            }
                        }
                    }
                    result = true;
                }
                catch (Exception ex)
                {
                    sMensagem = ex.Message;
                    result = false;
                }
                return result;
            }
            public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
            {
                DataTable dataTable = new DataTable();
                PropertyInfo[] array = null;
                DataTable result;
                if (varlist == null)
                {
                    result = dataTable;
                }
                else
                {
                    foreach (T current in varlist)
                    {
                        PropertyInfo[] array2;
                        if (array == null)
                        {
                            array = current.GetType().GetProperties();
                            array2 = array;
                            for (int i = 0; i < array2.Length; i++)
                            {
                                PropertyInfo propertyInfo = array2[i];
                                Type type = propertyInfo.PropertyType;
                                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    type = type.GetGenericArguments()[0];
                                }
                                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, type));
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        array2 = array;
                        for (int i = 0; i < array2.Length; i++)
                        {
                            PropertyInfo propertyInfo = array2[i];
                            dataRow[propertyInfo.Name] = ((propertyInfo.GetValue(current, null) == null) ? DBNull.Value : propertyInfo.GetValue(current, null));
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    result = dataTable;
                }
                return result;
            }
        }
    }
}
