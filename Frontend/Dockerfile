FROM node:alpine

WORKDIR /app/Online-Store-App.CommonLib

COPY Online-Store-App.CommonLib/package*.json ./

RUN npm install

RUN npm run build

WORKDIR /app/Online-Store-App.Staff

COPY Online-Store-App.Staff/package*.json ./

RUN npm install

WORKDIR /app

COPY . .

EXPOSE 3000

WORKDIR /app/Online-Store-App.Staff

CMD ["npm", "run", "dev"]