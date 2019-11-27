using CleanStrike.Core.Engine;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using CleanStrike.Core.Settings;
using CleanStrike.Core.Repositories;
using CleanStrike.Core.Models;

namespace CleanStrike
{
    class CleanStrikeApp
    {
        private readonly ICleanStrikeService _cleanStrikeService;
        private readonly ILogger<CleanStrikeApp> _logger;
        private readonly ApplicationSettings _config;
        private readonly ICarromBoardRepository _carromBoardRepository;

        public CleanStrikeApp(ICleanStrikeService cleanStrikeService,IOptions<ApplicationSettings> config,
            ILogger<CleanStrikeApp> logger,ICarromBoardRepository carromBoardRepository)
        {            
            _logger = logger;
            _config = config.Value;
            _carromBoardRepository = carromBoardRepository;
            _cleanStrikeService = cleanStrikeService;
        }

        public void Run()
        {
            CleanStrikeGame cleanStrikeGame=_carromBoardRepository.InitializeClearStrikeGame();
            List<IStrikeType> strikeLists=cleanStrikeGame.InitializeStrikeList();
            Console.WriteLine(" =======================================");
            Console.WriteLine("        Starting the Clean Strike App");
            Console.WriteLine(" =======================================");
            _cleanStrikeService.PlayGame(cleanStrikeGame,strikeLists);
        }
    }
}
