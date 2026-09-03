# RabbitMQConsumer

## 1. Overview

RabbitMQConsumer is a simple .NET console application that connects to a RabbitMQ broker and consumes messages from a configured queue. It is intended as a minimal, adaptable example for learning or integrating a message consumer into background services.

## 2. Description

The application establishes a connection to RabbitMQ using host, port, and credentials provided via environment variables (or application configuration). It declares/ensures the target queue exists and registers a consumer callback to receive and process messages. Message processing logic is implemented in Program.cs and can be adapted to your needs (logging, forwarding, persisting, etc.).

## 3. Pre-requisites

- .NET 10 SDK (https://dotnet.microsoft.com)
- A running RabbitMQ server (local or remote)
- Recommended: Git for cloning the repository

Running RabbitMQ in WSL (Windows)

If you run RabbitMQ inside WSL (for example Ubuntu), ensure WSL networking is configured so Windows tools can access the broker. Add a file named `.wslconfig` in your Windows user profile (C:\Users\<YourUser>\.wslconfig) with the following contents to enable mirrored networking:

```
[wsl2]
networkingMode=mirrored
```

After editing `.wslconfig`, restart WSL with:

```powershell
wsl --shutdown
```

Then start your WSL distribution and ensure RabbitMQ is running inside it (for example: `sudo service rabbitmq-server start`). When using mirrored networking you can typically use `localhost` from Windows; otherwise use the WSL instance IP address.

Required environment variables (defaults noted where applicable):

- RABBITMQ_HOST (default: localhost)
- RABBITMQ_PORT (default: 5672)
- RABBITMQ_USERNAME (default: guest)
- RABBITMQ_PASSWORD (default: guest)
- QUEUE_NAME (name of the queue to consume)

Example (Linux / macOS / WSL shell):

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

## 4. Build and Run

1. Clone the repository and open the project folder:

```bash
git clone https://github.com/atishagarwaal/RabbitMQConsumer.git
cd RabbitMQConsumer
```

2. Restore and build the project:

```bash
dotnet restore
dotnet build --configuration Release
```

3. Set the required environment variables (see examples above).

4. Run the consumer:

```bash
dotnet run --project .
```

Or run the published binary:

```bash
dotnet publish -c Release -o ./publish
./publish/RabbitMQConsumer
```

The application will connect to the configured RabbitMQ instance and begin consuming messages from the specified queue. Check Program.cs for the message handling implementation and adjust as needed.
