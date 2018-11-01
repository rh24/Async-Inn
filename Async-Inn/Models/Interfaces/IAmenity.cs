using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;

namespace AsyncInn.Interfaces
{
    public interface IAmenity
    {
        // Below are the CRUD actions that any class that implements this interface must do:

        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="amenity">Accepts an amenity object</param>
        /// <returns>Task object that is useful for async actions. Task objects do not actually have a return value.</returns>
        Task CreateAmenity(Amenity amenity);

        /// <summary>
        /// READ
        /// </summary>
        /// <returns>Task<TResult> represents a single action that has returns a value identified within the angle brackets. In this case, the Task object holds an IEnumerable collection of Amenity objects.</returns>
        Task<IEnumerable<Amenity>> GetAmenities();

        // Why is this nullable? Wouldn't this deflect to /Amenities if there is no id provided?
        // Is it meant to account for '/Amenities/' ?
        /// <summary>
        /// READ - grab a single amenity by id
        /// </summary>
        /// <param name="id">amenity's id</param>
        /// <returns>Task object</returns>
        Task GetAmenity(int? id);

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="amenity">amenity object to update</param>
        /// <returns>Task object with no return value</returns>
        Task UpdateAmenity(Amenity amenity);

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id">id of amenity to delete from db</param>
        /// <returns>Task object</returns>
        Task DeleteAmenity(int id);
    }
}
