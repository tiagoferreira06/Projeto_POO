/// \file Program.cs
/// \brief Classe principal do programa.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ObjetosDeNegocio;
using Excecoes;
using RegrasDeNegocio;
using Dados;

namespace Main
{
    /// \class Program
    /// \brief Classe principal responsavel pela execução do programa.
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Prepara o Programa
                // Prepara o Programa, criando o primeiro utilizador e adicionando-o a lista.
                Utilizador u1 = new Utilizador(1, 3, "ADMIN", "ADMIN");
                Utilizadores.AdicionarUser(u1);

                #endregion

            }
            #region Catches
            //Faz o catch de todas as exceções do projeto
            catch (ExcecaoApartamentoRegras)
            {

            }
            catch (ExcecaoReservaRegras)
            {

            }
            catch (ExcecaoUtilizadorRegras)
            {

            }
            catch (ExcecaoApartamento)
            {

            }
            catch (ExcecaoReservas)
            {

            }
            catch (ExcecaoUtilizadores)
            {

            }
            catch (ExcecaoValidarApartamento)
            {

            }
            catch (ExcecaoValidarReserva)
            {

            }
            catch (ExcecaoValidarUser)
            {

            }
            #endregion
        }
    }
}
