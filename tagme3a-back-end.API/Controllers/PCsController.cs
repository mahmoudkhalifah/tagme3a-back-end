using Microsoft.AspNetCore.Authorization;
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
        [Route("GetAllPrdPc")]
        public ActionResult<List<PrdPCInsertDTO>> GetAllPrdPc()
        {
            return _pcManager.getAllPrdPc().ToList();
        }
        [HttpGet]
        [Route("{id}")]

        public ActionResult<PCReadDetailsDTO> GetDetails(int id)
        {
            return _pcManager.GetDetails(id);
        }


        [HttpPost]
        [Authorize(Constants.Authorize.Admin)]

        public ActionResult<bool> InsertPc(PCInsertDTO data)
        {
            return _pcManager.InsertPC(data);
        }

        [HttpPost]
        [Route("InsertProductPc")]
        [Authorize(Constants.Authorize.Admin)]

        public ActionResult<bool> InsertPrdPc(PrdPCInsertDTO prd)
        {
            return _pcManager.InsertPrdPC(prd);
        }

        [HttpPut]
        [Route("UpdateProductPc/{id}")]
        [Authorize(Constants.Authorize.Admin)]

        public ActionResult<bool> UpdatePrdPc(int id , PrdPCUpdateDTO prd)
		{
			return _pcManager.UpdatePrdPC(id, prd);
		}

		[HttpPut]
        [Route("{id}")]
        [Authorize(Constants.Authorize.Admin)]

        public ActionResult<bool> UpdatePc(int id , PCInsertDTO data)
        {
            return _pcManager.UpdatePC(id, data);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Constants.Authorize.Admin)]

        public ActionResult<bool> DeletePc(int id) 
        {
            return _pcManager.DeletePC(id);
        }

        [HttpDelete]
        [Route("DeletePrdPC/{id}")]
        [Authorize(Constants.Authorize.Admin)]


        public ActionResult<bool> DeletePrdPC(int id , PrdPcDeleteDTO prdpc)
        {
            return _pcManager.DeletePrdPC(id, prdpc);
        }
    }
}
