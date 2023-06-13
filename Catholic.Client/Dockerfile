FROM node:alpine
WORKDIR /app
COPY . .
COPY package*.json ./
RUN npm ci
RUN npm run build
EXPOSE 3000
CMD ["npm", "start"]