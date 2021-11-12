using System;

namespace MMQ
{
	/// <summary>
	///     Represents a queue backed by memory that may be shared between different processes
	///     on the same machine.
	///     The queue exists until disposed of. Once disposed, <see cref="IMemoryMappedQueueProducer" />
	///     and <see cref="IMemoryMappedQueueConsumer" /> may no longer work and most methods throw an
	///     <see cref="InvalidOperationException" />.
	/// </summary>
	public interface IMemoryMappedQueue
		: IDisposable
	{
		/// <summary>
		/// Creates a new producer that is capable of enqueueing new messages
		/// into this queue.
		/// </summary>
		/// <remarks>
		/// This method is meant to be used when the producer is inside the same process
		/// as the owner of the queue. Otherwise, <see cref="MemoryMappedQueue.CreateProducer"/>
		/// should be used.
		/// </remarks>
		/// <returns></returns>
		IMemoryMappedQueueProducer CreateProducer();

		/// <summary>
		/// Creates a new consumer that is capable of dequeueing messages
		/// from this queue.
		/// </summary>
		/// <remarks>
		/// This method is meant to be used when the consumer is inside the same process
		/// as the owner of the queue. Otherwise, <see cref="MemoryMappedQueue.CreateConsumer"/>
		/// should be used.
		/// </remarks>
		/// <returns></returns>
		IMemoryMappedQueueConsumer CreateConsumer();
	}
}