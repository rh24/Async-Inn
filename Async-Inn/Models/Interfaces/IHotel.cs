using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;

namespace AsyncInn.Interfaces
{
    public interface IHotel
    {
        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="hotel">Accepts a hotel object</param>
        /// <returns>Task object that is useful for async actions. Task objects do not actually have a return value.</returns>
        Task CreateHotel(Hotel hotel);

        /// <summary>
        /// READ
        /// </summary>
        /// <returns>Task<TResult> represents a single action that has returns a value identified within the angle brackets. In this case, the Task object holds an IEnumerable collection of Hotel objects.</returns>
        Task<IEnumerable<Hotel>> GetHotels();

        /// <summary>
        /// READ - grab a single hotel by id
        /// </summary>
        /// <param name="id">amenity's id</param>
        /// <returns>Task object</returns>
        Task GetHotel(int? id);

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="hotel">hotel object to update</param>
        /// <returns>Task object with no return value</returns>
        Task UpdateHotel(Hotel hotel);

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id">id of hotel to delete from db</param>
        /// <returns>Task object</returns>
        Task DeleteHotel(int id);
    }
}
