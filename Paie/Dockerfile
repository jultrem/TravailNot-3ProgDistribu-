FROM node:14
WORKDIR /app
COPY package*.json ./
RUN npm install 
COPY ./paie.js /app/
EXPOSE 8501
CMD ["node", "paie.js"]