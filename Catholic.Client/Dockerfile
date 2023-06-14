FROM node:current-alpine3.17
WORKDIR /app
COPY ./Catholic.Client/package.json /app/package.json
COPY ./Catholic.Client/package-lock.json /app/package-lock.json
RUN npm ci
COPY ./Catholic.Client .
RUN npm run build
EXPOSE 3000
CMD ["npm", "start"]