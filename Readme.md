## I have developed my solution with Clean Architecture and REST Api

## Benefits of Clean Architecture

    - Independent of Database and Frameworks.
    - Independent of the presentation layer. Anytime we can change the UI without 
    changing the rest of the system and business logic. 
    - Highly testable, especially the core domain model and its business 
    rules are extremely testable.

## Postman Test collection file 
    Postman Test collection file has been prepared to test the API. 
    You can reach the collection from "PaymentApi.postman_collection.json" in this repository.
   
# How to containarize our app

    docker-compose up 

## or manual register and run docker image by following instructions

    -docker build -t paymentapi .

## get image id from this list 
    
    -docker images 


## direct run from the image
    
    - docker run -t payment-api

## or run by image-id

    - docker run -it --rm <image-id>

# I have shared below which some other useful docker commands 

## create container from image

    -docker create --name payment-api payment-api <image-id>

## start container
    -docker start payment-api

## stop container
    -docker stop payment-api

## remove container

    -docker rm payment-api

## remove docker image by id 

    docker rmi <image-id>

