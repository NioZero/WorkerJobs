# Worker App

This is a basic worker 

## How to Build

Build the image as a Docker using

```
docker build -f WorkerApp\Dockerfile -t workerapp .
```
## Create Kubernete CronJobs

```
kubectl apply -f kube/cronjob-job1.yaml
kubectl apply -f kube/cronjob-job2.yaml
```
