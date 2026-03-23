using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DuoiHinhBatChu.DAL;
using DuoiHinhBatChu.DAL.Entites;

namespace DuoiHinhBatChu.BLL
{
    public class PlayerService
    {
        public void AddOrUpdate(Player player)
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                db.Players.AddOrUpdate(player);
                db.SaveChanges();
            }
        }
        public List<Player> GetAll()
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                return db.Players.ToList();
            }
        }
        public Player GetByName(string name)
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                return db.Players.FirstOrDefault(p => p.PlayerName == name);
            }
        }
    }
}
