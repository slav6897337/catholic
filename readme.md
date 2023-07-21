apt update
apt upgrade -y

apt install -y docker.io
apt install docker-compose
systemctl enable --now docker

create files docker compose and config for nginx

docker-compose up -d


create folder
/root/catholic/certbot/.well-known/acme-challenge

change nginx config
location /.well-known/acme-challenge/ {
root /var/www/certbot;
try_files $uri =404;
}

docker-compose run --rm --entrypoint "\
certbot certonly --webroot -w /var/www/certbot \
--email slava6897337@gmail.com \
-d catholic-dev.store -d www.catholic-dev.store -d holymass-dev.store -d www.holymass-dev.store \
--agree-tos --force-renewal" certbot

docker-compose up -d

docker-compose ps -a

docker-compose logs nginx