DROP TABLE IF EXISTS customer;
CREATE TABLE IF NOT EXISTS customer
(
    index integer not null,
    customer_id character varying(16),
    first_name character varying(255),
    last_name character varying(255),
    company character varying(255),
    city character varying(255),
    country character varying(255),
    phone_1 character varying(255),
    phone_2 character varying(255),
    email character varying(255),
    subscription_date character varying(255),
    website character varying(255),
    CONSTRAINT customer_pkey PRIMARY KEY (index)
)
TABLESPACE pg_default;

ALTER TABLE IF EXISTS customer
    OWNER to postgres;
