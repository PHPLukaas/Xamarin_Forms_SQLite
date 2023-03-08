using System;
using System.Threading.Tasks;
using SQLite;
using Xamarin_Forms_SQLite.Models;

namespace Xamarin_Forms_SQLite.Repositories
{
    public class HumeurRepository
    {
        protected SQLiteAsyncConnection _connection;
        private int nbHumeurs;
        private string Message;
        private string monHumeur;

        public HumeurRepository(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Humeur>();
        }

        public async Task AjouterHumeurAsync(string commentaire, int note, DateTime dateAjout)
        {
            try
            {
                nbHumeurs = await _connection.InsertAsync(new Humeur { Commentaire = commentaire, Note = note, DateAjout = dateAjout });
                // Gestion d'un message à afficher
                Message = $"Humeur du jour ajoutée : {commentaire}.\n {monHumeur}.\n {dateAjout}";
            }
            catch (Exception e)
            {
                Message = $"Impossible d'ajouter l'humeur : {commentaire}.\n Erreur : {e.Message}";
            }
        }

    }
}