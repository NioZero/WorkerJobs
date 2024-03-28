# Worker App

This is a basic .NET console application that I create with the goal to manage multiple jobs that can be shared in the same image but with different CronJobs in Kubernetes.

## How it Works

Jobs are defined in the file [Jobs.cs](/NioZero/WorkerJobs/blob/main/WorkerApp/Jobs.cs). During execution you must pass parameter `--job=JobName` to execute an specific Job. 

## How to Build

This project was intented to work in Kubernetes using CronJobs, so you must build the image first and then create the CronJobs using the example provided.

### 1. Build Docker

The file `Dockerfile` is included in the repository so to build the project you can simply use the following command (you can specify any tag as needed)

```
docker build -f WorkerApp\Dockerfile -t workerapp:latest .
```
### 2. Create CronJobs

You can use `.yaml` examples in the folder `kube`. Each CronJob use its own file. If you're using `kubectl` you can simply create the jobs using the command

```
kubectl apply -f kube/cronjob-job1.yaml
kubectl apply -f kube/cronjob-job2.yaml
```

## How to Contribute

This is basically an example project, but if you want to contribute adding something, you can freely create an Issue or a Pull Request.

