#!/bin/sh
docker login -e $DOCKER_EMAIL -u $DOCKERHUB_USERNAME -p $DOCKERHUB_PASSWORD
TAG="latest"
docker build -f Dockerfile -t $TRAVIS_REPO_SLUG:$TAG .
docker push $TRAVIS_REPO_SLUG