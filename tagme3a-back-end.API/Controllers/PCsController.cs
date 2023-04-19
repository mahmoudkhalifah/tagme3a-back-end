using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.PC;
using tagme3a_back_end.BL.Managers.PCManager;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly IPCManager _pcManager;

        public PCsController(IPCManager pcManager)
        {
            this._pcManager = pcManager;
        }

        [HttpGet]
        public ActionResult<List<PCReadDTO>> GetAll()
        {
            return _pcManager.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<PCReadDetailsDTO> GetDetails(int id)
        {
            return _pcManager.GetDetails(id);
        }


        [HttpPost]
        public ActionResult<bool> InsertPc(PCInsertDTO data)
        {
            return _pcManager.InsertPC(data);
        }

        [HttpPost]
        [Route("InsertProductPc")]

        public ActionResult<bool> InsertPrdPc(PrdPCInsertDTO prd)
        {
            return _pcManager.InsertPrdPC(prd);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<bool> UpdatePc(int id , PCInsertDTO data)
        {
            return _pcManager.UpdatePC(id, data);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> DeletePc(int id) 
        {
            return _pcManager.DeletePC(id);
        }
    }
}
