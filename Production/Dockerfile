FROM python:3.10.6

WORKDIR /code

COPY ./requirements.txt /code/requirements.txt

RUN pip install --no-cache-dir --upgrade -r /code/requirements.txt

COPY *.py /code/

CMD uvicorn main:app --proxy-headers --host 0.0.0.0 --port ${PORT}