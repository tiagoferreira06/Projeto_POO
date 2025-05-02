/// \file RegrasReservas.cs
/// \brief Classe para gerir as regras de permissões relacionadas às reservas.
/// \details Esta classe define regras específicas para criar, atualizar, remover e guardar reservas.
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
    /// \class RegrasReservas
    /// \brief Classe estatica para gerir regras de permissões de reservas.
    public static class RegrasReservas
    {

        #region PermissoesReserva

        /// \brief Tenta criar uma reserva.
        /// \param id Identificador unico da reserva.
        /// \param idap Identificador do apartamento associado.
        /// \param idUtilizador Identificador do utilizador associado.
        /// \param dataInicio Data de inicio da reserva.
        /// \param dataFim Data de fim da reserva.
        /// \param hospedes Numero de hospedes na reserva.
        /// \return Retorna true se a reserva foi criada com sucesso.
        /// \throws ExececaoReservaRegras Caso a criação da reserva falhe.
        public static bool TentaCriarReserva(int id, int idap, int idUtilizador, DateTime dataInicio, DateTime dataFim, int hospedes)
        {
            if (Reservas.CriarReserva(id, idap, idUtilizador, dataInicio, dataFim, hospedes) == true)
            {
                return true;
            }
            throw new ExcecaoReservaRegras(2);

        }

        /// \brief Tenta atualizar uma reserva com base nas permissões do utilizador.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param id Identificador da reserva a ser atualizada.
        /// \param idNovo Novo identificador da reserva.
        /// \param idHotel Identificador do hotel associado à reserva atual.
        /// \param idHotelNovo Novo identificador do hotel.
        /// \param idUtilizadorNovo Novo identificador do utilizador associado.
        /// \param dataInicio Nova data de inicio da reserva.
        /// \param dataFim Nova data de fim da reserva.
        /// \param hospedes Novo numero de hospedes.
        /// \return Retorna true se a reserva foi atualizada com sucesso.
        /// \throws ExececaoReservaRegras Caso o utilizador não tenha permissão para atualizar.
        public static bool TentaAtualizarReserva(int idU, int id, int idNovo, int idHotel, int idHotelNovo, int idUtilizadorNovo, DateTime dataInicio, DateTime dataFim, int hospedes)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm == 3 || u.Perm == 2)
            {
                Reservas.AtualizarReserva(id, idNovo, idHotel, idHotelNovo, idUtilizadorNovo, dataInicio, dataFim, hospedes);
                return true;
            }
            else
            {
                throw new ExcecaoReservaRegras(1);
            }
        }

        /// \brief Tenta remover uma reserva com base nas permissões do utilizador.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param id Identificador unico da reserva.
        /// \return Retorna true se a reserva foi removida com sucesso.
        /// \throws ExececaoReservaRegras Caso o utilizador não tenha permissão para remover.
        public static bool TentaRemoverReserva(int idU, int id, int idApartamento)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm == 3)
            {
                Reservas.RemoverReserva(id, idApartamento);
                return true;
            }
            else
            {
                throw new ExcecaoReservaRegras(1);
            }
        }

        /// \brief Tenta cancelar uma reserva com base nas permissões do utilizador.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param id Identificador unico da reserva.
        /// \return Retorna true se a reserva foi cancelada com sucesso.
        /// \throws ExececaoReservaRegras Caso o utilizador não tenha permissão para cancelar.
        public static bool TentaCancelarReserva(int idU, int id, int idApartamento)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm >= 2)
            {
                Reservas.CancelarReserva(id, idApartamento);
                return true;
            }
            else
            {
                throw new ExcecaoReservaRegras(1);
            }
        }

        /// \brief Guarda as reservas num ficheiro, desde que o utilizador atual tenha permissão.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param fileName Nome do ficheiro onde os dados serão salvos.
        /// \return Retorna true se as reservas foram guardadas com sucesso.
        /// \throws ExececaoReservaRegras Caso o utilizador não tenha permissão para guardar.
        public static bool TentaGuardarReservasFicheiro(int idU, string fileName)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoReservaRegras(1);
            }
            else
            {
                Reservas.GuardarReservasFicheiro(fileName);
                return true;
            }
        }

        /// \brief Le as reservas num ficheiro, desde que o utilizador atual tenha permissão.
        /// \param idU Id do Utilizador a realizar a operação.
        /// \param fileName Nome do ficheiro onde os dados serão lidos.
        /// \return Retorna true se as reservas foram lidas com sucesso.
        /// \throws ExececaoReservaRegras Caso o utilizador não tenha permissão para ler.
        public static bool TentaLerReservasFicheiro(int idU, string fileName)
        {
            Utilizador u = Utilizadores.BuscarUserPorId(idU);

            if (u == null)
            {
                throw new ExcecaoUtilizadores(2);
            }

            if (u.Perm != 3)
            {
                throw new ExcecaoReservaRegras(1);
            }
            else
            {
                Reservas.LerReservasFicheiro(fileName);
                return true;
            }
        }

        #endregion

    }
}
