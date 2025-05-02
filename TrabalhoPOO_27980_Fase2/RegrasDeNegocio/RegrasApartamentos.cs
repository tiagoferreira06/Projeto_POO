/// \file RegrasApartamentos.cs
/// \brief Classe para gerir as regras de permissões relacionadas aos apartamentos.
/// \details Esta classe define regras específicas para criar, atualizar, remover e guardar apartamentos.
/// \author Tiago Ferreira
/// \date 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excecoes;
using ObjetosDeNegocio;
using Dados;

namespace RegrasDeNegocio
{
    /// \class RegrasApartamentos
    /// \brief Classe estatica para gerir regras de permissões de apartamentos.
    public static class RegrasApartamentos
    {

        #region PermissoesApartamentos

        /// <summary>
        /// \brief Tenta criar um apartamento com base nas permissões do utilizador.
        /// </summary>
        /// <param name="idU">ID do Utilizador</param>
        /// <param name="id">ID do apartamento</param>
        /// <param name="nome">Nome do apartamento</param>
        /// <param name="endereco">Endereço fisico do apartamento</param>
        /// <param name="valorDiaria">Valor Diario do apartamento</param>
        /// <param name="capacidade">Capacidade do apartamento</param>
        /// <param name="disponivel">Disponibilidade do apartamento</param>
        /// <param name="wifi">Possui Wi-Fi ou nao.</param>
        /// <returns></returns>
        /// <exception cref="ExcecaoUtilizadores"></exception>
        /// <exception cref="ExcecaoApartamentoRegras"></exception>
        public static bool TentaCriarApartamento(int idU, int id, string nome, string endereco, double valorDiaria, int capacidade, bool disponivel, bool wifi)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoApartamentoRegras(1);
            }
            else
            {
                Apartamentos.CriarApartamento(id, nome, endereco, valorDiaria, capacidade, disponivel, wifi);
                return true;
            }
        }

        #region AdicionarHotel 
        /*        
        public static bool AdicionarHotel(Utilizador u, int id)
        {
            if (u.Perm != 3)
            {
                Console.WriteLine("Perms insuficientes");
                return false;
            }
            else
            {
                Hoteis.AdicionarHotel(Hoteis.BuscarHotelPorId(id));
                Console.WriteLine("Hotel Adicionado.");
                return true;
            }

        }
        */
        #endregion


        /// <summary>
        /// \brief Tenta atualizar os dados de um apartamento com base nas permissões do utilizador.
        /// </summary>
        /// <param name="idU">ID do Utilizador</param>
        /// <param name="id">ID do apartamento</param>
        /// <param name="idNovo">ID Novo do apartamento</param>
        /// <param name="nome">Nome novo do apartamento</param>
        /// <param name="endereco">Endereço novo do apartamento</param>
        /// <param name="valorDiaria">Valor Diario novo do apartamento</param>
        /// <param name="capacidade">Capacidade nova do apartamento</param>
        /// <param name="disponivel">Disponibilidade do apartamento</param>
        /// <param name="wifi">Possui ou não Wi-Fi</param>
        /// <returns></returns>
        /// <exception cref="ExcecaoUtilizadores"></exception>
        /// <exception cref="ExcecaoApartamentoRegras"></exception>
        public static bool TentaAtualizarApartamento(int idU, int id, int idNovo, string nome, string endereco, double valorDiaria, int capacidade, bool disponivel, bool wifi)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm == 2 || u.Perm == 3)
            {
                Apartamentos.AtualizarApartamento(id, idNovo, nome, endereco, valorDiaria, capacidade, disponivel, wifi);
                return true;
            }
            else
            {
                throw new ExcecaoApartamentoRegras(1);
            }
        }

        /// <summary>
        /// \brief Tenta remover um apartamento com base nas permissões do utilizador.
        /// </summary>
        /// <param name="idU">ID do Utilizador</param>
        /// <param name="idApartamento"></param>
        /// <returns></returns>
        /// <exception cref="ExcecaoUtilizadores"></exception>
        /// <exception cref="ExcecaoApartamentoRegras"></exception>
        public static bool TentaRemoverApartamento(int idU, int idApartamento)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoApartamentoRegras(1);
            }
            else
            {
                Apartamentos.RemoverApartamento(idApartamento);
                return true;
            }
        }

        /// <summary>
        /// \brief Guarda os dados dos apartamentos num ficheiro, desde que o utilizador tenha permissão.
        /// </summary>
        /// <param name="idU">ID do Utilizador</param>
        /// <param name="fileName">String do ficheiro a criar ou adicionar</param>
        /// <returns></returns>
        /// <exception cref="ExcecaoUtilizadores"></exception>
        /// <exception cref="ExcecaoApartamentoRegras"></exception>
        public static bool TentarGuardarApartamentosFicheiro(int idU, string fileName)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoApartamentoRegras(1);
            }
            else
            {
                Apartamentos.GuardarApartamentosFicheiro(fileName);
                return true;
            }
        }

        /// <summary>
        /// \brief Le os dados dos apartamentos a partir de um ficheiro, desde que o utilizador tenha permissão.
        /// </summary>
        /// <param name="idU">ID do Utilizador</param>
        /// <param name="fileName">Nome do ficheiro a ser lido</param>
        /// <returns></returns>
        /// <exception cref="ExcecaoUtilizadores"></exception>
        /// <exception cref="ExcecaoApartamentoRegras"></exception>
        public static bool TentarLerApartamentosFicheiro(int idU, string fileName)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoApartamentoRegras(1);
            }
            else
            {
                Apartamentos.LerApartamentosFicheiro(fileName);
                return true;
            }
        }

        #endregion

    }
}
