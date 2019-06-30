# MMQ

[![Build status](https://ci.appveyor.com/api/projects/status/dqn0aug6qs46xt2y?svg=true)](https://ci.appveyor.com/project/Kittyfisto/mmq)
[![NuGet](https://img.shields.io/nuget/dt/mmq.svg)](http://nuget.org/packages/mmq)
[![NuGet](https://img.shields.io/nuget/v/mmq.svg)](http://nuget.org/packages/mmq)

Queue backed by a memory mapped file for IPC

This project features a queue implementation that allows for the exchange of messages between different applications on the same
machine.

# Usage

Process A

    using (var queue = MemoryMappedQueue.Create("UniqueName"))
    using (var producer = queue.CreateProducer())
    {
        var message = Encoding.UTF8.GetBytes("Hello, World!");
        producer.Enqueue(message);

        Console.WriteLine("Press any key to cancel");
        Console.ReadLine();
    }



Process B

    using (var consumer = MemoryMappedQueue.CreateConsumer("UniqueName"))
    {
        var message = consumer.Dequeue();
        var text = Encoding.UTF8.GetString(message);
        Console.WriteLine(text);
    }
