using GalacticTitans.Core.Domain.SupportingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.Core.Domain
{
    public class TitanOwnership 
    {
        public Guid ID { get; set; }

        public string TitanName { get; set; }
        public TitanType TitanType { get; set; }
        public int TitanHealth { get; set; }
        public int TitanXP { get; set; }
        public int TitanXPNextLevel { get; set; }
        public int TitanLevel { get; set; }
        public TitanStatus TitanStatus { get; set; }
        public string PrimaryAttackName { get; set; }
        public int PrimaryAttackPower { get; set; }
        public string SecondaryAttackName { get; set; }
        public int SecondaryAttackPower { get; set; }
        public string SpecialAttackName { get; set; }
        public int SpecialAttackPower { get; set; }
        public DateTime TitanWasBorn { get; set; }
        public DateTime TitanDied { get; set; }
        public string? OwnedByPlayerProfile { get; set; } //is string but holds guid, id of player whom the ownership belongs to
        public string? IsOwnershipOfThisTitan { get; set; } //is string but holds guid, id of titan that this ownership is based on

        //db only
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
