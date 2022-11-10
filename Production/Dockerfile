FROM python:3.9

WORKDIR /code

COPY ./requirements.txt /code/requirements.txt

RUN pip install --no-cache-dir --upgrade -r /code/requirements.txt

COPY ./main.py /code/

<<<<<<< HEAD
CMD uvicorn main:app --proxy-headers --host 0.0.0.0 --port 8510
=======
ENTRYPOINT uvicorn app.main:app --host 0.0.0.0 --port ${PORT}
>>>>>>> b0ec23bcdeac2ced84eb049947d68f98a7fefb05
