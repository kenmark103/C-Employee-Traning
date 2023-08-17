using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface ILocationCommands
    {
        Task<LocationResults> CreateLocation(CreateLocationRequest locationRequest);
        Task<LocationUpdatedResults> UpdateLocation(Guid locationId, UpdateLocationRequest updatedLocation);
        Task<LocationUpdatedResults> DeleteLocation(Guid locationId);
    }
    public class LocationCommands : ILocationCommands
    {
        private readonly EFTestDbContext _dbContext;

        public LocationCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LocationResults> CreateLocation(CreateLocationRequest locationRequest)
        {
            Location location = new Location()
            {
                Name = locationRequest.Name,
                CreatedDate = DateTime.Now,
                Id = locationRequest.Id
            };
            try {
                _dbContext.Locations.Add(location);
                await _dbContext.SaveChangesAsync();

            } catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            

            LocationResults results = new LocationResults()
            {
                Name = location.Name,

            };

            return results;
        }

        public async Task<LocationUpdatedResults> DeleteLocation(Guid locationId)
        {
            var location = await _dbContext.Locations.FindAsync(locationId);
            if (location != null)
            {
                try
                {
                    _dbContext.Locations.Remove(location);
                    await _dbContext.SaveChangesAsync();
                    return new LocationUpdatedResults()
                    {
                        Success = true,
                    };
                }
                catch (Exception ex)
                {
                    return new LocationUpdatedResults { Success = false, ErrorMessage = ex.Message };
                }
            }
            else { return new LocationUpdatedResults() { Success = false, ErrorMessage = "Could not find location" }; }
        }

        public async Task <LocationUpdatedResults> UpdateLocation(Guid locationId, UpdateLocationRequest updatedLocation)
        {
            var location = await _dbContext.Locations.FindAsync(locationId);
            if (location != null)
            {
                location.Name = updatedLocation.Name;

                await _dbContext.SaveChangesAsync();

                LocationUpdatedResults locationUpdated = new LocationUpdatedResults()
                {
                    Name = location.Name,
                    Success = true
                };

                return locationUpdated;
            }
            else
            {
                return new LocationUpdatedResults() { Success = false, ErrorMessage = "Couldnot find location" };
            }

        }
    }
}
