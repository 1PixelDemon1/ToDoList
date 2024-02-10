# To-Do List Web Application

## Русский

Веб приложение "Список дел" состоит из frontend-части, написанной на angular, и backend-части, написанной на asp.net core. 
Приложение предоставляет интерфейс к базовым CRUD операциям над делами, группами дел, а также пользователями этих дел. Позволяет делиться делами с другими пользователями и следить за их выполнением.

Backend приложения построен на чистой архитектуре(clean architecture) с применением паттернов:
* Репозиторий (Repository)
* Единица работы (Unit Of Work)
* CQRS
* Посредник (Mediator)
## Развертывание

Для того, чтобы развернуть приложение необходимо установить [Docker](https://www.docker.com/).
* Затем необходимо скачать файл [docker-compose](https://github.com/1PixelDemon1/ToDoListWebApplication/blob/main/docker-compose.yml) из репозитория.
* По расположению файла запустить контейнеры docker при помощи следующей консольной команды:
```bash
  docker-compose up
```
## Тестирование
После запуска контейнеров на localhost по порту 80 будет работать frontend приложение

## English

The To-Do List Web Application consists of a frontend part written in angular and a backend part written in asp.net core. 
The application provides an interface to basic CRUD operations on tasks, groups of tasks, and users of those tasks. It allows sharing tasks with other users and tracking their progress.

The backend of the application is built on a clean architecture using patterns:
* Repository
* Unit Of Work
* CQRS
* Mediator
## Deployment

In order to deploy the application you need to install [Docker](https://www.docker.com/).
* Then you need to download the [docker-compose](https://github.com/1PixelDemon1/ToDoListWebApplication/blob/main/docker-compose.yml) file from the repository.
* Based on the location of the file, start the docker containers using the following console command:
```bash
  docker-compose up
```
## Testing
After starting the containers on localhost on port 80, the frontend application will be running
