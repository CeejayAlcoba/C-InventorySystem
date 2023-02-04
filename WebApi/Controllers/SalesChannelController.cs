using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [Route("api/saleschannel")]
    [ApiController]
    [Authorize]
    public class SalesChannelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesChannelService _salesChannelService;
        public SalesChannelController(IUnitOfWork unitOfWork, ISalesChannelService salesChannelService)
        {
            _salesChannelService = salesChannelService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult SalesChannelList()
        {
            var salesChannel = _unitOfWork.SalesChannels.GetAll();
            return Ok(salesChannel);
        }
        [HttpPost]
        public IActionResult AddSalesChannel([FromBody] SalesChannel salesChannel)
        {
            var getSalesChannel = _salesChannelService.AddSalesChannel(salesChannel);
            if (getSalesChannel != null)
            {
                return Ok(getSalesChannel);
            }
            return BadRequest("Name already exists");

        }
        [HttpPatch]
        [Route("/api/saleschannel/id/{id}")]
        public IActionResult UpdateSalesChannel(int Id, [FromBody] SalesChannel salesChannel)
        {
            var salesChannelId = _unitOfWork.SalesChannels.GetById(Id);
            var getSalesChannel = _unitOfWork.SalesChannels.GetSalesChannelByName(salesChannel.Name);
            if (salesChannelId.Name != salesChannel.Name)
            {
                if (getSalesChannel == null)
                {
                    _salesChannelService.UpdateSalesChannel(salesChannel, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name already exists");
                }

            }
            else
            {
                _salesChannelService.UpdateSalesChannel(salesChannel, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/saleschannel/id/{id}")]
        public IActionResult GetSalesChannel(int Id)
        {
            var salesChannel = _unitOfWork.SalesChannels.GetById(Id);
            return Ok(salesChannel);

        }
        [HttpDelete]
        [Route("/api/saleschannel/id/{id}")]
        public IActionResult DeleteSalesChannel(int Id)
        {
            try
            {
                

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
