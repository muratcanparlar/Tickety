-- Create table for Event
-- Create table for Category
CREATE TABLE category (
    id uuid NOT NULL PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    is_archived boolean NOT NULL DEFAULT false
);

-- Create table for Event
CREATE TABLE event (
    id uuid NOT NULL PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    description TEXT NOT NULL,
    location VARCHAR(200) NOT NULL,
    starts_at_utc timestamp(6) without time zone NOT NULL,
    ends_at_utc timestamp(6) without time zone NOT NULL,
    status int NOT NULL,
    category_id uuid NOT NULL,
    CONSTRAINT fk_event_category FOREIGN KEY(category_id) REFERENCES category(id)
);

-- Create table for TicketType
CREATE TABLE ticket_type (
    id uuid NOT NULL PRIMARY KEY,
    event_id uuid NOT NULL,
    name VARCHAR(200) NOT NULL,
    price numeric(18,2) NOT NULL,
    currency VARCHAR(3) NOT NULL,
    quantity integer NOT NULL,
    created_at_utc timestamp(6) without time zone NOT NULL,
    updated_at_utc timestamp(6) without time zone NULL,
    CONSTRAINT fk_ticket_type_event FOREIGN KEY(event_id) REFERENCES event(id)
);

CREATE INDEX ix_ticket_type_event_id ON ticket_type(event_id);
