#!/bin/bash

# Get a list of image IDs for images with the <none> tag
image_ids=$(docker images -f "dangling=true" -q)

# Check if there are any images to remove
if [ -n "$image_ids" ]; then
  # Remove the images
  docker rmi $image_ids
  echo "Successfully removed Docker images with the <none> tag."
else
  echo "No Docker images with the <none> tag found."
fi



docker pull slava6897337/catholic-client:master

docker pull slava6897337/catholic-api:master

docker-compose up -d --remove-orphans

image_ids=$(docker images -f "dangling=true" -q)

if [ -n "$image_ids" ]; then
  docker rmi $image_ids
  echo "Successfully removed Docker images with the <none> tag."
else
  echo "No Docker images with the <none> tag found."
fi