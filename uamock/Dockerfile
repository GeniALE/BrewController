FROM python:slim

WORKDIR /app

EXPOSE 4840

COPY requirements.txt requirements.txt

RUN pip3 install -r requirements.txt

COPY ./src ./src

ENTRYPOINT [ "python3", "./src/main.py"]
