using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.PC;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Managers.PCManager
{
    public interface IPCManager
    {
        IEnumerable<PCReadDTO> GetAll();
        public PCReadDetailsDTO GetDetails(int id);
        public void CalcPrice(decimal price,int quantity, int pcId);
        public bool InsertPC(PCInsertDTO pc);
        public bool InsertPrdPC(PrdPCInsertDTO pc);
        public bool UpdatePC(int id, PCInsertDTO pc);
        public bool UpdatePrdPC(int id, PrdPCUpdateDTO pc);
        public bool DeletePrdPC(int id, PrdPcDeleteDTO Prdpc);

        public IEnumerable<PrdPCInsertDTO> getAllPrdPc();

		public bool DeletePC(int id);

    }
}
