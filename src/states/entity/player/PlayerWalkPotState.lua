PlayerWalkPotState = Class { __includes = EntityWalkState }

function PlayerWalkPotState:init(entity, dungeon)
    self.entity = entity
    self.dungeon = dungeon
    self.pot = self.entity.Pot
    self.entity.offsetY = 5
    self.entity.offsetX = 0
    self.bumped = false
    self.entity:changeAnimation('walk-pot-' .. self.entity.direction)
end

function PlayerWalkPotState:update(dt)
    if love.keyboard.isDown('return') then
        self.pot.projectile = true
        self.pot.direction = self.entity.direction
        self.pot.entities = self.dungeon.currentRoom.entities
        self.entity:changeState('idle')
    elseif love.keyboard.isDown('left') then
        self.entity.direction = 'left'
        self.entity:changeAnimation('walk-pot-left')
    elseif love.keyboard.isDown('right') then
        self.entity.direction = 'right'
        self.entity:changeAnimation('walk-pot-right')
    elseif love.keyboard.isDown('up') then
        self.entity.direction = 'up'
        self.entity:changeAnimation('walk-pot-up')
    elseif love.keyboard.isDown('down') then
        self.entity.direction = 'down'
        self.entity:changeAnimation('walk-pot-down')
    else
        self.entity:changeState('idle-pot')
    end
    --EntityWalkState.update(self, dt)
    EntityWalkState.update(self, dt)

    -- if we bumped something when checking collision, check any object collisions
    if self.bumped then
        if self.entity.direction == 'left' then
            -- temporarily adjust position into the wall, since bumping pushes outward
            self.entity.x = self.entity.x - PLAYER_WALK_SPEED * dt

            -- check for colliding into doorway to transition
            for k, doorway in pairs(self.dungeon.currentRoom.doorways) do
                if self.entity:collides(doorway) and doorway.open then
                    -- shift entity to center of door to avoid phasing through wall
                    self.entity.y = doorway.y + 4
                    Event.dispatch('shift-left')
                end
            end

            -- readjust
            self.entity.x = self.entity.x + PLAYER_WALK_SPEED * dt
        elseif self.entity.direction == 'right' then
            -- temporarily adjust position
            self.entity.x = self.entity.x + PLAYER_WALK_SPEED * dt

            -- check for colliding into doorway to transition
            for k, doorway in pairs(self.dungeon.currentRoom.doorways) do
                if self.entity:collides(doorway) and doorway.open then
                    -- shift entity to center of door to avoid phasing through wall
                    self.entity.y = doorway.y + 4
                    Event.dispatch('shift-right')
                end
            end

            -- readjust
            self.entity.x = self.entity.x - PLAYER_WALK_SPEED * dt
        elseif self.entity.direction == 'up' then
            -- temporarily adjust position
            self.entity.y = self.entity.y - PLAYER_WALK_SPEED * dt

            -- check for colliding into doorway to transition
            for k, doorway in pairs(self.dungeon.currentRoom.doorways) do
                if self.entity:collides(doorway) and doorway.open then
                    -- shift entity to center of door to avoid phasing through wall
                    self.entity.x = doorway.x + 8
                    Event.dispatch('shift-up')
                end
            end

            -- readjust
            self.entity.y = self.entity.y + PLAYER_WALK_SPEED * dt
        else
            -- temporarily adjust position
            self.entity.y = self.entity.y + PLAYER_WALK_SPEED * dt

            -- check for colliding into doorway to transition
            for k, doorway in pairs(self.dungeon.currentRoom.doorways) do
                if self.entity:collides(doorway) and doorway.open then
                    -- shift entity to center of door to avoid phasing through wall
                    self.entity.x = doorway.x + 8
                    Event.dispatch('shift-down')
                end
            end

            -- readjust
            self.entity.y = self.entity.y - PLAYER_WALK_SPEED * dt
        end
    end
    self.pot.x = self.entity.x
    self.pot.y = self.entity.y - 5
end

function PlayerWalkPotState:render()
    local anim = self.entity.currentAnimation
    love.graphics.draw(gTextures[anim.texture], gFrames[anim.texture][anim:getCurrentFrame()],
        math.floor(self.entity.x - self.entity.offsetX), math.floor(self.entity.y - self.entity.offsetY))
end
