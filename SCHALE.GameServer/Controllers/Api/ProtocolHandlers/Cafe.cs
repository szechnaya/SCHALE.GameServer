using SCHALE.Common.Database;
using SCHALE.Common.FlatData;
using SCHALE.Common.NetworkProtocol;
using SCHALE.GameServer.Services;

namespace SCHALE.GameServer.Controllers.Api.ProtocolHandlers
{
    public class Cafe : ProtocolHandlerBase
    {
        private ISessionKeyService sessionKeyService;
        private SCHALEContext context;

        public Cafe(IProtocolHandlerFactory protocolHandlerFactory, ISessionKeyService _sessionKeyService, SCHALEContext _context) : base(protocolHandlerFactory)
        {
            sessionKeyService = _sessionKeyService;
            context = _context;
        }

        [ProtocolHandler(Protocol.Cafe_Get)]
        public ResponsePacket GetHandler(CafeGetInfoRequest req)
        {
            var account = sessionKeyService.GetAccount(req.SessionKey);
            var cafeDb = account.Cafes.FirstOrDefault();
            return new CafeGetInfoResponse()
            {
                CafeDB = cafeDb,
                CafeDBs = account.Cafes.ToList(),
                FurnitureDBs = cafeDb.FurnitureDBs
            };
        }

        public static CafeDB CreateCafe(long accountId)
        {
            return new()
            {
                CafeDBId = 0,
                CafeId = 0,
                AccountId = accountId,
                CafeRank = 0,
                LastUpdate = DateTime.Now,
                LastSummonDate = DateTime.MinValue,
                CafeVisitCharacterDBs = new(),
                FurnitureDBs = new()
                {
                    new() { UniqueId = 1, }
                },
                ProductionAppliedTime = DateTime.Now,
                ProductionDB = new(),
            };
        }
    }
}
