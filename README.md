# RabbitMQConsumer

.NET Console Application using RabbitMQ for receiving messages from a queue.

## Overview

This is a small .NET console app that connects to a RabbitMQ broker and consumes messages from a configured queue. It is intended as a simple consumer example you can adapt for background services or integrations.

## Prerequisites

- .NET SDK 6.0 or later (https://dotnet.microsoft.com)
- A running RabbitMQ server (local or remote)

## Configuration

The application reads RabbitMQ connection values from environment variables. If your project uses a different configuration approach, update the code or provide an `appsettings.json` accordingly.

Environment variable examples:

- RABBITMQ_HOST (default: `localhost`)
- RABBITMQ_PORT (default: `5672`)
- RABBITMQ_USERNAME (default: `guest`)
- RABBITMQ_PASSWORD (default: `guest`)
- QUEUE_NAME (name of the queue to consume)

Example (Linux / macOS):

```bash
export RABBITMQ_HOST=localhost
export RABBITMQ_PORT=5672
export RABBITMQ_USERNAME=guest
export RABBITMQ_PASSWORD=guest
export QUEUE_NAME=task_queue
```

Example (Windows PowerShell):

```powershell
$env:RABBITMQ_HOST = "localhost"
$env:RABBITMQ_PORT = "5672"
$env:RABBITMQ_USERNAME = "guest"
$env:RABBITMQ_PASSWORD = "guest"
$env:QUEUE_NAME = "task_queue"
```

## Build and run

1. Clone the repository and change into the project directory:

```bash
git clone https://github.com/atishagarwaal/RabbitMQConsumer.git
cd RabbitMQConsumer
```

2. Build the project:

```bash
dotnet build
```

3. Run the consumer:

```bash
dotnet run --project ./
```

The consumer will connect to the configured RabbitMQ instance and start printing/processing incoming messages from the configured queue.

## How it works

- The app creates a connection to RabbitMQ using the supplied host, port, and credentials.
- It declares/ensures the queue exists and sets up a consumer callback.
- When messages arrive they are processed by the consumer logic (see Program.cs).

## Contributing

Contributions are welcome — open an issue or PR with improvements or bug fixes.

## License

This repository does not include a license. If you want to reuse this code, please add a license file or contact the repository owner.
