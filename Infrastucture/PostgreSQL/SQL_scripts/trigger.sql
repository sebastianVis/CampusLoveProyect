DROP TRIGGER IF EXISTS trig_actualizar_matches ON matches;

-- Eliminar la función existente (si existe)
DROP FUNCTION IF EXISTS actualizar_estadisticas_match();

-- Volver a crear la función
CREATE OR REPLACE FUNCTION actualizar_estadisticas_match()
RETURNS TRIGGER AS $$
BEGIN
    -- Agregar depuración para ver qué está ocurriendo
    RAISE NOTICE 'Trigger ejecutado: Actualizando estadísticas para usuarios % y %', NEW.id_usuario_uno, NEW.id_usuario_dos;
    
    -- Actualizar estadisticas para el primer usuario
    UPDATE estadisticas
    SET total_matches = COALESCE(total_matches, 0) + 1,
        ultima_actualizacion = NOW()
    WHERE id_usuario = NEW.id_usuario_uno;
    
    -- Actualizar estadisticas para el segundo usuario
    UPDATE estadisticas
    SET total_matches = COALESCE(total_matches, 0) + 1,
        ultima_actualizacion = NOW()
    WHERE id_usuario = NEW.id_usuario_dos;
    
    -- Retornar el NEW registro para completar la inserción
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Crear el trigger nuevamente
CREATE TRIGGER trig_actualizar_matches
AFTER INSERT ON matches
FOR EACH ROW
EXECUTE FUNCTION actualizar_estadisticas_match();