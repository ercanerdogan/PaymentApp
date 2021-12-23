-Benefits of Clean Architecture

    Independent of Database and Frameworks.
    Independent of the presentation layer. Anytime we can change the UI without changing the rest of the system and business logic.
    Highly testable, especially the core domain model and its business rules are extremely testable.


How to containarize our app

-docker build -t paymentapi .

-docker images 

#get image id from this list 

#direct run from the image
docker run -t payment-api

#or run by image-id
docker run -it --rm <image-id>


dotnet dev-cers https --trust

#create container from image

-docker create --name payment-api payment-api <image-id>


#start container
-docker start payment-api


#stop container
-docker stop payment-api


#remove container

docker rm payment-api

#remove docker image by id 

docker rmi <image-id>



